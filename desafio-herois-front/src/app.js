function abrirFormulario() {
  document.getElementById('formulario').style.display = 'block';
}

function fecharFormulario() {
  document.getElementById('formulario').style.display = 'none';
}

function salvarHeroi() {
  alert("Herói salvo (teste)");
}

// Expor para HTML
window.abrirFormulario = abrirFormulario;
window.fecharFormulario = fecharFormulario;
window.salvarHeroi = salvarHeroi;
