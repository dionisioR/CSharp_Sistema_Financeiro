using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers {
    public class ClienteController : Controller {

        ClienteNeg objClienteNeg;
        // construtor - abre a conexão
        public ClienteController() {
            objClienteNeg = new ClienteNeg();
        }


        // GET: Cliente - Mostra os clientes
        public ActionResult Index() {
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }

        public ActionResult Lista() {
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create() {
            mensagemInicioRegistrar();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente objCliente) {
            mensagemInicioRegistrar();
            objClienteNeg.create(objCliente);
            MensagemErroRegistrar(objCliente);
            ModelState.Clear();
            return View("Create");
        }

        [HttpPost]
        public ActionResult Createe(Cliente objCliente) {
            mensagemInicioRegistrar();
            objClienteNeg.create(objCliente);
            MensagemErroRegistrar(objCliente);
            ModelState.Clear();
            return View("Create");
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        //mensagem de erro
        public void MensagemErroRegistrar(Cliente objCliente) {

            switch (objCliente.Estado) {

                case 1000://campo cpf com letras
                    ViewBag.MensagemErro = "Erro CPF, não insira Letras";
                    break;

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira Nome do Cliente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 30 caracteres";
                    break;


                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira CPF do Cliente";
                    break;

                case 250://campo cpf vazio
                    ViewBag.MensagemErro = "O CPF deve ter 11 dígitos, apenas números";
                    break;

                case 60://endereco vazio
                    ViewBag.MensagemErro = "Insira endereço do Cliente";
                    break;

                case 6://erro no endereço
                    ViewBag.MensagemErro = "Campo endereço não pode ter mais de 50 caracteres";
                    break;

                case 70://campo telefone vazio
                    ViewBag.MensagemErro = "Insira o telefone do cliente";
                    break;

                case 7://campo telefone vazio
                    ViewBag.MensagemErro = "O telefone tem que ter de 8 a 15 digitos";
                    break;

                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Cliente [" + objCliente.IdCliente + "] já está registrado no sistema";
                    break;

                case 9://erro de duplicidade
                    ViewBag.MensagemErro = "Numero de CPF [" + objCliente.Cpf + "] já está registrado no sistema";
                    break;

                case 99://Cliente Salvo com Sucesso
                    ViewBag.MensagemExito = "Cliente [" + objCliente.Nome + " " + "] foi inserido no sistema";
                    break;

            }

        }

        public void mensagemInicioRegistrar() {
            ViewBag.MensagemInicio = "Insira os dados do Cliente e clique em salvar";
        }

    }
}
