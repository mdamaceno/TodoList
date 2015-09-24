using Corridas.Access;
using Corridas.Model;
using Corridas.Processamento;
using Corridas.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corridas.ViewModel
{
    public class EditarCorridaViewModel : NotifyPropertyBase
    {
        private Corrida Corrida;

        public Command CancelarCommand { get; set; }
        public Command SalvarCommand { get; set; }

        public EditarCorridaViewModel()
        {
            this.CancelarCommand = new Command((p) => { this.Cancelar(); });
            this.SalvarCommand = new Command((p) => { this.Salvar(); });

            var l = CorridaDAO.Entities.LocalEntity.GetAll();
            this.locais = new ObservableCollection<Local>(l);
        }

        public void Salvar()
        {
            this.Corrida.Nome = this.nome;
            this.Corrida.Local = this.LocalSelecionado;

            this.view.Close();
        }

        private void Cancelar()
        {
            this.view.Close();
        }

        public void Execute(Corrida corrida)
        {
            this.Corrida = corrida;

            this.nome = corrida.Nome;

            var ls = this.Locais.
                  FirstOrDefault(f => f.Cidade_Uf == corrida.Local.Cidade_Uf);

            this.LocalSelecionado = ls;

            this.view.ShowDialog();
        }

        private string nome;
        public string Nome
        {
            get { return this.nome; }
            set {
                if (this.nome == value)
                    return;

                this.nome = value;
                OnPropertyChanged("Nome");
            }
        }

        private EditarCorridaView view;
        public EditarCorridaView View
        {
            get { return this.view; }
            set {                
                this.view = value;
                this.view.Title = "Editando Corrida";    
            }
        }

        private ObservableCollection<Local> locais;
        public ObservableCollection<Local> Locais
        {
            get { return this.locais; }
            set
            {
                if (this.locais == value)
                    return;                               

                this.locais = value;
                OnPropertyChanged("Locais");
            }
        }

        private Local localSelecionado;
        public Local LocalSelecionado
        {
            get { return this.localSelecionado; }
            set
            {
                if (this.localSelecionado == value)
                    return;

                this.localSelecionado = value;
                OnPropertyChanged("LocalSelecionado");
            }
        }
    }
}
