using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AviaMediator
{
   public class BaseAircraft
    {
        protected IMediator mediator;
        public TextBox messageView;
        public static Graphics g;
        public BaseAircraft(IMediator mediator = null)
        {
            this.mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
     public class Airplane : BaseAircraft
    {
        public void Clear() {
            g.FillRectangle(new SolidBrush(Color.WhiteSmoke), 152, 210, 128, 129);
            messageView.Text = "";
        }
        public void Posadka()
        {
            //Thread.Sleep(1000);

            messageView.Text = "Запрошую посадку";
            
            //Thread.Sleep(1000);
            //Console.WriteLine(" ");
            g.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject("Arrow2"), 152, 210, 128, 129);

            this.mediator.Notify(this, "запит на посадку літака");
        }
        public void Vilit()
        {
            //Thread.Sleep(1000);
            messageView.Text = "Виліт дозволяєте? Прийом.";
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("Arrow2"), 152, 210, 128, 129);
            this.mediator.Notify(this, "запит на виліт літака");
            //Console.WriteLine(" ");
        }


        public void EndPosadka()
        {
           messageView.Text= "Посадку завершено";
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("Arrow2"), 152, 210, 128, 129);
            this.mediator.Notify(this, "літак сів");
        }
        public void EndVilit()
        {
            messageView.Text = "Літак вилетів";
            g.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("Arrow2"), 152, 210, 128, 129);
            this.mediator.Notify(this, "літак вилетів");
        }
    }

   public class Helicopter : BaseAircraft
    {
        public void Clear()
        {
            messageView.Text = "";
            g.FillRectangle(new SolidBrush(Color.WhiteSmoke), 477, 210, 128, 129);
        }
        public void Posadka()
        {
            //Thread.Sleep(1000);
            messageView.Text = "Запрошую посадку";
            g.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject("Arrow3"), 477, 210, 128, 129);
            


            this.mediator.Notify(this, "запит на посадку гелікоптера");
        }
        public void Vilit()
        {
            messageView.Text = "Виліт дозволяєте? Прийом.";

            g.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject("Arrow3"), 477, 210, 128, 129);
            this.mediator.Notify(this, "запит на виліт гелікоптера");
        }
        public void EndPosadka()
        {
            messageView.Text = "Посадку завершено";
            g.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject("Arrow3"), 477, 210, 128, 129);
            this.mediator.Notify(this, "гелікоптер сів");
        }
        public void EndVilit()
        {
            messageView.Text = "Гелікоптер вилетів";
            g.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject("Arrow3"), 477, 210, 128, 129);
            this.mediator.Notify(this, "гелікоптер вилетів");
        }
    }
}
