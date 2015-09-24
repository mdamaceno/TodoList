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
using System.Windows;

namespace Corridas.ViewModel
{
    public class MainWindowViewModel : NotifyPropertyBase
    {
        public Command FecharCommand { get; set; }
        public Command ExcluirCommand { get; set; }
        public Command IncluirCommand { get; set; }
        public Command EditarCommand { get; set; }
        
        public MainWindowViewModel()
        {
            this.FecharCommand = new Command((p) => { this.Fechar(); });
            this.ExcluirCommand = new Command((p) => { this.Excluir(); });
            this.IncluirCommand = new Command((p) => { this.Incluir(); });
            this.EditarCommand = new Command((p) => { this.Editar(); });

            this.data = DateTime.Now;

            var local = CorridaDAO.Entities.LocalEntity.GetAll();
            var corrida = CorridaDAO.Entities.CorridaEntity.GetAll();

            this.corridas = new ObservableCollection<Corrida>(corrida);
            this.local = new ObservableCollection<Local>(local);                       
        }

        private MainWindow view;
        public MainWindow View
        {
            get { return this.view; }
            set
            {               
                this.view = value;
            }
        }

        private void Editar()
        {
            var viewModel = new EditarCorridaViewModel();
            viewModel.View = new EditarCorridaView();
            viewModel.View.DataContext = viewModel;

            viewModel.Execute(this.CorridaSelecionada);

            CorridaDAO.Entities.CorridaEntity.Alterar(this.corridaSelecionada);

            this.view.grdCorrida.Items.Refresh();
        }

        private void Incluir()
        {
            var corrida = new Corrida()
            {
                Distancia = this.distancia,
                DataCorrida = this.data,
                Nome = this.nome,
                Local = this.LocalSelecionado
            };
            
            CorridaDAO.Entities.CorridaEntity.Inserir(corrida);

            var c = CorridaDAO.Entities.CorridaEntity.GetAll();

            this.Corridas = new ObservableCollection<Corrida>(c);

            this.view.grdCorrida.Items.Refresh();
        }

        private void Excluir()
        {
            CorridaDAO.Entities.CorridaEntity.Delete(this.corridaSelecionada.Id);
            this.corridas.Remove(this.corridaSelecionada);            
        }

        public void Fechar()
        {
            System.Environment.Exit(0);
        }

        private ObservableCollection<Corrida> corridas;
        public ObservableCollection<Corrida> Corridas
        {
            get { return this.corridas; }
            set
            {
                if (this.corridas == value)
                    return;

                this.corridas = value;
                OnPropertyChanged("Corridas");
            }
        }

        private ObservableCollection<Local> local;
        public ObservableCollection<Local> Local
        {
            get { return this.local; }
            set
            {
                if (this.local == value)
                    return;

                this.local = value;
                OnPropertyChanged("Local");
            }
        }

        private Corrida corridaSelecionada;
        public Corrida CorridaSelecionada
        {
            get { return this.corridaSelecionada; }
            set
            {
                if (this.corridaSelecionada == value)
                    return;

                this.corridaSelecionada = value;
                OnPropertyChanged("CorridaSelecionada");
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

        private string nome;
        public string Nome
        {
            get { return this.nome; }
            set
            {
                if (this.nome == value)
                    return;

                this.nome = value;
                OnPropertyChanged("Nome");
            }
        }

        private DateTime data;
        public DateTime Data
        {
            get { return this.data; }
            set
            {
                if (this.data == value)
                    return;

                this.data = value;
                OnPropertyChanged("Data");
            }
        }

        private int distancia;
        public int Distancia
        {
            get { return this.distancia; }
            set
            {
                if (this.distancia == value)
                    return;

                this.distancia = value;
                OnPropertyChanged("Distancia");
            }
        }
    }
}
