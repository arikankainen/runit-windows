using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace RunIt
{
    public partial class Form1
    {
        private Panel sourceShortcut;
        private FlowLayoutPanel sourceGroup;

        private bool draggingShortcut = false;
        private bool draggingGroup = false;

        private int originX, originY;
        private int originMouseX, originMouseY;

        private PictureBox picDragPreview = new PictureBox();
        private bool dragPreviewCreated = false;

        private int mouseDownX = 0;
        private int mouseDownY = 0;
        private int mouseDownDist = 10;

        // ********************* ADD SHORTCUT ***************************

        private void addShortcut(string fileSource, string destGroup)
        {
            string sourcePathAndFilename = fileSource;
            string sourcePath = Path.GetDirectoryName(fileSource);
            string sourceFileName = Path.GetFileName(fileSource);
            string sourceFileNameOnly = Path.GetFileNameWithoutExtension(fileSource);
            string sourceFileExt = Path.GetExtension(sourceFileName);

            string destPathName = Path.Combine(setFolder, destGroup);
            string destPathAndFileName = Path.Combine(destPathName, sourceFileNameOnly + ".lnk");

            if (sourceFileExt == ".lnk")
            {
                File.Copy(fileSource, getUniqueName(destPathAndFileName));
            }

            else if (sourceFileExt == ".exe")
            {
                string newFileNameOnly = sourceFileNameOnly;

                var versionInfo = FileVersionInfo.GetVersionInfo(sourcePathAndFilename);
                string versionDesc = versionInfo.FileDescription;
                if (versionDesc != null & versionDesc != "") newFileNameOnly = removeIllegalChars(versionDesc);

                string tempPathAndFilename = Path.Combine(destPathName, newFileNameOnly + ".lnk");
                newFileNameOnly = Path.GetFileNameWithoutExtension(getUniqueName(tempPathAndFilename));

                saveShortcut(destPathName, newFileNameOnly, sourcePathAndFilename);
            }

            else
            {
                string newFileNameOnly = Path.GetFileNameWithoutExtension(getUniqueName(destPathAndFileName));

                saveShortcut(destPathName, newFileNameOnly, sourcePathAndFilename);
            }
        }

        private string getUniqueName(string name)
        {
            string file = Path.Combine(Path.GetDirectoryName(name), Path.GetFileNameWithoutExtension(name));

            DirectoryInfo root = new DirectoryInfo(Path.GetDirectoryName(file));
            FileInfo[] listfiles = root.GetFiles(Path.GetFileName(file) + ".*");

            if (listfiles.Length > 0)
            {
                for (int i = 1; i < 9999; i++)
                {
                    string fileTemp = file + " (" + i.ToString() + ")";
                    DirectoryInfo root2 = new DirectoryInfo(Path.GetDirectoryName(fileTemp));
                    FileInfo[] listfiles2 = root.GetFiles(Path.GetFileName(fileTemp) + ".*");

                    if (listfiles2.Length == 0)
                    {
                        return fileTemp + ".lnk";
                    }
                }
            }

            return file + ".lnk";
        }

        private string removeIllegalChars(string file)
        {
            string invalidChars = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalidChars)
            {
                file = file.Replace(c.ToString(), "");
            }

            return file;
        }

        // ********************* MOVE ***************************

        private void moveGroup(FlowLayoutPanel sourceGroup, FlowLayoutPanel destGroup)
        {
            int index = flowLayoutPanel1.Controls.GetChildIndex(destGroup, false);

            flowLayoutPanel1.Controls.SetChildIndex(sourceGroup, index);
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Invalidate();
            flowLayoutPanel1.ResumeLayout();

            resizeGroups();
            resizeWindow();
        }

        private void moveShortcut(Panel sourceShortcut, Panel destShortcut, FlowLayoutPanel sourceGroup, FlowLayoutPanel destGroup)
        {
            if (destShortcut != null)
            {
                if (sourceGroup == destGroup)
                {
                    int index = destGroup.Controls.GetChildIndex(destShortcut, false);
                    destGroup.Controls.SetChildIndex(sourceShortcut, index);
                    destGroup.SuspendLayout();
                    destGroup.Invalidate();
                    destGroup.ResumeLayout();
                }

                else
                {
                    string fileSource = sourceShortcut.Tag.ToString();
                    string fileDest = Path.Combine(Path.GetDirectoryName(destShortcut.Tag.ToString()), Path.GetFileName(fileSource));
                    string fileSourcePng = fileSource.Replace(".lnk", ".png");
                    string fileDestPng = fileDest.Replace(".lnk", ".png");

                    if (!File.Exists(fileDest))
                    {
                        File.Move(fileSource, fileDest);
                        if (File.Exists(fileSourcePng)) File.Move(fileSourcePng, fileDestPng);

                        int index = destGroup.Controls.GetChildIndex(destShortcut, false);
                        sourceShortcut.Tag = fileDest;
                        destGroup.Controls.Add(sourceShortcut);
                        destGroup.Controls.SetChildIndex(sourceShortcut, index);
                        destGroup.SuspendLayout();
                        destGroup.Invalidate();
                        destGroup.ResumeLayout();
                    }
                }
            }

            else if (sourceGroup != destGroup)
            {
                string fileSource = sourceShortcut.Tag.ToString();
                string fileDest = Path.Combine(Path.Combine(setFolder, destGroup.Tag.ToString()), Path.GetFileName(fileSource));
                string fileSourcePng = fileSource.Replace(".lnk", ".png");
                string fileDestPng = fileDest.Replace(".lnk", ".png");

                if (!File.Exists(fileDest))
                {
                    File.Move(fileSource, fileDest);
                    if (File.Exists(fileSourcePng)) File.Move(fileSourcePng, fileDestPng);

                    sourceShortcut.Tag = fileDest;
                    destGroup.Controls.Add(sourceShortcut);
                    destGroup.SuspendLayout();
                    destGroup.Invalidate();
                    destGroup.ResumeLayout();
                }
            }

            resizeGroups();
            resizeWindow();
        }

        // ********************** SHORTCUT DRAG **************************

        private void shortcutPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseDownX == 0 && mouseDownY == 0)
            {
                mouseDownX = Cursor.Position.X;
                mouseDownY = Cursor.Position.Y;
            }
        }

        private void shortcutPanelChild_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseDownX == 0 && mouseDownY == 0)
            {
                mouseDownX = Cursor.Position.X;
                mouseDownY = Cursor.Position.Y;
            }
        }

        private void shortcutPanel_MouseMove(object sender, MouseEventArgs e)
        {
            bool moved = false;

            if (mouseDownX != 0 && mouseDownY != 0)
            {
                if (Cursor.Position.X > mouseDownX + mouseDownDist) moved = true;
                else if (Cursor.Position.X < mouseDownX - mouseDownDist) moved = true;
                else if (Cursor.Position.Y > mouseDownY + mouseDownDist) moved = true;
                else if (Cursor.Position.Y < mouseDownY - mouseDownDist) moved = true;
            }

            if (e.Button == MouseButtons.Left && moved)
            {
                draggingShortcut = true;
                draggingGroup = false;
                sourceShortcut = (Panel)sender;
                sourceGroup = (FlowLayoutPanel)sourceShortcut.Parent;

                if (!dragPreviewCreated)
                {
                    Bitmap bmp = new Bitmap(sourceShortcut.Width, sourceShortcut.Height);
                    sourceShortcut.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
                    Bitmap resized = resizeImage(bmp, (int)(bmp.Width / 1.5), (int)(bmp.Height / 1.5));

                    picDragPreview.Top = this.PointToClient(Cursor.Position).Y + 10;
                    picDragPreview.Left = this.PointToClient(Cursor.Position).X + 10;
                    picDragPreview.Width = resized.Width;
                    picDragPreview.Height = resized.Height;
                    picDragPreview.Parent = this;
                    picDragPreview.Visible = true;
                    picDragPreview.Image = resized;
                    this.Controls.Add(picDragPreview);
                    picDragPreview.BringToFront();

                    dragPreviewCreated = true;
                    timerDrag.Start();
                }

                DoDragDrop(this, DragDropEffects.All);
            }
        }

        private void shortcutPanelChild_MouseMove(object sender, MouseEventArgs e)
        {
            bool moved = false;

            if (mouseDownX != 0 && mouseDownY != 0)
            {
                if (Cursor.Position.X > mouseDownX + mouseDownDist) moved = true;
                else if (Cursor.Position.X < mouseDownX - mouseDownDist) moved = true;
                else if (Cursor.Position.Y > mouseDownY + mouseDownDist) moved = true;
                else if (Cursor.Position.Y < mouseDownY - mouseDownDist) moved = true;
            }

            if (e.Button == MouseButtons.Left && moved)
            {
                draggingShortcut = true;
                draggingGroup = false;
                Control control = (Control)sender;
                sourceShortcut = (Panel)control.Parent;
                sourceGroup = (FlowLayoutPanel)sourceShortcut.Parent;

                if (!dragPreviewCreated)
                {
                    Bitmap bmp = new Bitmap(sourceShortcut.Width, sourceShortcut.Height);
                    sourceShortcut.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
                    Bitmap resized = resizeImage(bmp, (int)(bmp.Width / 1.5), (int)(bmp.Height / 1.5));

                    picDragPreview.Top = this.PointToClient(Cursor.Position).Y + 10;
                    picDragPreview.Left = this.PointToClient(Cursor.Position).X + 10;
                    picDragPreview.Width = resized.Width;
                    picDragPreview.Height = resized.Height;
                    picDragPreview.Parent = this;
                    picDragPreview.Visible = true;
                    picDragPreview.Image = resized;
                    this.Controls.Add(picDragPreview);
                    picDragPreview.BringToFront();

                    dragPreviewCreated = true;
                    timerDrag.Start();
                }

                DoDragDrop(this, DragDropEffects.All);
            }
        }

        private void shortcutPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void shortcutPanelChild_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void shortcutPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (draggingShortcut)
            {
                Panel destShortcut = (Panel)sender;
                FlowLayoutPanel destGroup = (FlowLayoutPanel)destShortcut.Parent;

                moveShortcut(sourceShortcut, destShortcut, sourceGroup, destGroup);
            }

            if (draggingGroup)
            {
                Control c = (Control)sender;
                FlowLayoutPanel destGroup = (FlowLayoutPanel)c.Parent;

                moveGroup(sourceGroup, destGroup);
            }
        }

        private void shortcutPanelChild_DragDrop(object sender, DragEventArgs e)
        {
            if (draggingShortcut)
            {
                Control temp = (Control)sender;
                Panel destShortcut = (Panel)temp.Parent;
                FlowLayoutPanel destGroup = (FlowLayoutPanel)destShortcut.Parent;

                moveShortcut(sourceShortcut, destShortcut, sourceGroup, destGroup);
            }

            if (draggingGroup)
            {
                Control temp = (Control)sender;
                Panel c = (Panel)temp.Parent;
                FlowLayoutPanel destGroup = (FlowLayoutPanel)c.Parent;

                moveGroup(sourceGroup, destGroup);
            }
        }

        private void shortcutPanel_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Cursor.Current = Cursors.Default;
        }

        private void shortcutPanelChild_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Cursor.Current = Cursors.Default;
        }

        // ********************** GROUP DRAG **************************

        private void groupLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseDownX == 0 && mouseDownY == 0)
            {
                mouseDownX = Cursor.Position.X;
                mouseDownY = Cursor.Position.Y;
            }
        }

        private void groupLabel_MouseMove(object sender, MouseEventArgs e)
        {
            bool moved = false;

            if (mouseDownX != 0 && mouseDownY != 0)
            {
                if      (Cursor.Position.X > mouseDownX + mouseDownDist) moved = true;
                else if (Cursor.Position.X < mouseDownX - mouseDownDist) moved = true;
                else if (Cursor.Position.Y > mouseDownY + mouseDownDist) moved = true;
                else if (Cursor.Position.Y < mouseDownY - mouseDownDist) moved = true;
            }

            if (e.Button == MouseButtons.Left && moved)
            {
                draggingShortcut = false;
                draggingGroup = true;
                Label label = (Label)sender;
                sourceGroup = (FlowLayoutPanel)label.Parent;

                if (!dragPreviewCreated)
                {
                    Bitmap bmp = new Bitmap(sourceGroup.Width, sourceGroup.Height);
                    sourceGroup.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
                    Bitmap resized = resizeImage(bmp, (int)(bmp.Width / 1.5), (int)(bmp.Height / 1.5));

                    picDragPreview.Top = this.PointToClient(Cursor.Position).Y + 10;
                    picDragPreview.Left = this.PointToClient(Cursor.Position).X + 10;
                    picDragPreview.Width = resized.Width;
                    picDragPreview.Height = resized.Height;
                    picDragPreview.Parent = this;
                    picDragPreview.Visible = true;
                    picDragPreview.Image = resized;
                    this.Controls.Add(picDragPreview);
                    picDragPreview.BringToFront();

                    dragPreviewCreated = true;
                    timerDrag.Start();
                }

                DoDragDrop(this, DragDropEffects.All);
            }
        }

        private void groupLabel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void groupPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void groupLabel_DragDrop(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //{
            //    string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));

            //    foreach (string file in filePaths)
            //    {
            //        if (File.Exists(file))
            //        {
            //            MessageBox.Show(file);
            //        }

            //    }
            //}

            if (draggingShortcut)
            {
                Control c = (Control)sender;
                FlowLayoutPanel destGroup = (FlowLayoutPanel)c.Parent;

                moveShortcut(sourceShortcut, null, sourceGroup, destGroup);
            }

            else if (draggingGroup)
            {
                Control c = (Control)sender;
                FlowLayoutPanel destGroup = (FlowLayoutPanel)c.Parent;

                moveGroup(sourceGroup, destGroup);
            }
        }
        
        private void groupPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (draggingShortcut)
            {
                FlowLayoutPanel destGroup = (FlowLayoutPanel)sender;

                moveShortcut(sourceShortcut, null, sourceGroup, destGroup);
            }

            else if (draggingGroup)
            {
                FlowLayoutPanel destGroup = (FlowLayoutPanel)sender;

                moveGroup(sourceGroup, destGroup);
            }
        }

        private void groupLabel_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Cursor.Current = Cursors.Default;
        }

        private void groupPanel_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Cursor.Current = Cursors.Default;
        }

        // ********************** WINDOW DRAG **************************

        private void flow_MouseDown(object sender, MouseEventArgs e)
        {
            originX = this.Left;
            originY = this.Top;

            originMouseX = Cursor.Position.X;
            originMouseY = Cursor.Position.Y;
        }

        private void flow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int diffX = originMouseX - originX;
                int diffY = originMouseY - originY;

                int left = Cursor.Position.X - diffX;
                int right = left + this.Width;

                int top = Cursor.Position.Y - diffY;
                int bottom = top + this.Height;

                mouseX = this.Left + (this.Width / 2);
                mouseY = this.Top + (this.Height / 2);

                Screen screen = Screen.FromPoint(Control.MousePosition);

                if (left < screen.WorkingArea.Left + setLocationMargin) left = screen.WorkingArea.Left + setLocationMargin;
                if (right > screen.WorkingArea.Right - setLocationMargin) left = screen.WorkingArea.Right - setLocationMargin - this.Width;

                if (top < screen.WorkingArea.Top + setLocationMargin) top = screen.WorkingArea.Top + setLocationMargin;
                if (bottom > screen.WorkingArea.Bottom - setLocationMargin) top = screen.WorkingArea.Bottom - setLocationMargin - this.Height;

                this.Left = left;
                this.Top = top;

                windowDragged = true;
            }
        }

        // ************************************************

        private void timerDrag_Tick(object sender, EventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                picDragPreview.Top = this.PointToClient(Cursor.Position).Y + 10;
                picDragPreview.Left = this.PointToClient(Cursor.Position).X + 10;
            }

            else
            {
                timerDrag.Stop();
                dragPreviewCreated = false;
                picDragPreview.Visible = false;
                mouseDownX = 0;
                mouseDownY = 0;
            }
        }

        private static Bitmap resizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


    }
}
