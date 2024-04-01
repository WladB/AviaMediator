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
    public interface IMediator
    {
       void Notify(object sender, string ev);
    }

    public class ConcreteMediator : IMediator
    {
         Airplane airplane;

         Helicopter helicopter;
     

        public ConcreteMediator(Airplane a, Helicopter h)
        {
            airplane = a;
            airplane.SetMediator(this);
            helicopter = h;
            helicopter.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            switch (ev) {
                case "запит на посадку літака":
            
                MessageBox.Show("Вас зрозумів посадку літака дозволяю");

                this.airplane.EndPosadka();
                    break;
                case "запит на посадку гелікоптера":
                MessageBox.Show("Вас зрозумів посадку гелікоптера дозволяю");
                this.helicopter.EndPosadka();
                    break;
                case "літак сів":
                MessageBox.Show("Посадка літака успішна, прямуйте в ангар 212");
                    this.airplane.Clear();
                this.helicopter.Vilit();
                    break;
                case "гелікоптер сів":
                MessageBox.Show("Посадка гелікоптера успішна, прямуйте в ангар 215");
                    this.helicopter.Clear();
                    this.airplane.Posadka();
                    break;
                case "гелікоптер вилетів":
                MessageBox.Show("(Для гелікоптера) Вас зрозумів, курс західний, координати 12.78.56");
                    this.helicopter.Clear();
                    this.airplane.Vilit();
                    break;
                case "літак вилетів":
            
                MessageBox.Show("(Для літака) Вас зрозумів, курс південно-східний, координати 42.51.34");
                    this.airplane.Clear();
                    this.helicopter.Posadka();
                    break;
                case "запит на виліт гелікоптера":
            
                MessageBox.Show("(для гелікоптера)Вас зрозумів, виліт дозволяю");
                this.helicopter.EndVilit();
                    break;
                case "запит на виліт літака":
            
                MessageBox.Show("(для літака)Вас зрозумів, виліт дозволяю");
                this.airplane.EndVilit();
                    break;
            }
        }
    }
}
