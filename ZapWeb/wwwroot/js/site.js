"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/ZapWebHub").withAutomaticReconnect().build();

start();

connection.onclose(async (err) => {
    await start();
})

function start() {
    connection.start()
        .then(() => {
            console.info("Conectado.");
            habilitarCadastro();
            habilitarLogin();
        })
        .catch((err) => {
            console.error(err.toString());
            setTimeout(start(), 5000)
        });
}

var formCadastro = document.querySelector("#form-cadastro");

function habilitarCadastro() {
    if (formCadastro) {
        var btnCadastrar = document.querySelector("#btnCadastrar");

        btnCadastrar.addEventListener("click", () => {
            var nome = document.querySelector("#nome").value;
            var email = document.querySelector("#email").value;
            var senha = document.querySelector("#senha").value;

            var usuario = { Nome: nome, Email: email, Senha: senha };

            connection.invoke("Cadastrar", usuario)
                .then(() => {
                    console.info("Cadastrado com sucesso");
                })
                .catch((err) => {
                    console.error(err.toString());
                });
        })
    }

    connection.on("UsuarioCadastrado", (sucesso, usuario, msg) => {
        var mensagem = document.querySelector("#mensagem");
        if (sucesso) {
            console.info(usuario);

            document.querySelector("#nome").value = "";
            document.querySelector("#email").value = "";
            document.querySelector("#senha").value = "";
        }

        mensagem.innerHTML = msg;
    })
}

function habilitarLogin() {
    var formLogin = document.querySelector("#form-login");

    if (formLogin) {
        var btnAcessar = document.querySelector("#btnAcessar");

        btnAcessar.addEventListener("click", () => {
            var email = document.querySelector("#email").value;
            var senha = document.querySelector("#senha").value;

            var usuario = { Email: email, Senha: senha };

            connection.invoke("Login", usuario);
        });
    }

    connection.on("UsuarioLogado", (sucesso, usuario, msg) => {
        if (sucesso) {
            setUsuarioLogado(usuario);
            window.location.href = "/Home/Conversacao";
        } else {
            var mensagem = document.querySelector("#mensagem");
            mensagem.innerHTML = msg;
        }
    });
}

function getUsuarioLogado() {
    return JSON.parse(sessionStorage.getItem("Logado"));
}

function setUsuarioLogado(usuario) {
    sessionStorage.setItem("Logado", JSON.stringify(usuario));
}