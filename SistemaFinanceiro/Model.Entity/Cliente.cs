using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity {
    public class Cliente {
        private long idCliente;
        private string nome;
        private string cpf;
        private string endereco;
        private string telefone;
        private int estado;

        public Cliente() { }

        public Cliente(long idCliente)
        {
            this.idCliente = idCliente;
        }

        public Cliente(long idCliente, string nome, string cpf, string endereco, string telefone) {
            this.idCliente = idCliente;
            this.nome = nome;
            this.cpf = cpf;
            this.endereco = endereco;
            this.telefone = telefone;
        }

        [Display(Name="Código")]
        public long IdCliente { get => idCliente; set => idCliente = value; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage ="O campo nome é obrigatório.")]
        public string Nome { get => nome; set => nome = value; }

        [Display(Name ="CPF")]
        public string Cpf { get => cpf; set => cpf = value; }

        [Display(Name ="Endereço")]
        public string Endereco { get => endereco; set => endereco = value; }

        [Display(Name ="Telefone")]
        public string Telefone { get => telefone; set => telefone = value; }

        public int Estado { get => estado; set => estado = value; }
    }
}
