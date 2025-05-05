
const formulario = document.getElementById('formulario');
const listaHerois = document.getElementById('listaHerois');


formulario.addEventListener('submit', function (event) {
  event.preventDefault();


  const nomeHeroi = document.getElementById('nomeHeroi').value;
  const dataNascimento = document.getElementById('dataNascimento').value;
  const altura = document.getElementById('altura').value;
  const peso = document.getElementById('peso').value;
  const superpoderes = document.getElementById('superpoderes').value;


  const li = document.createElement('li');


  li.textContent = `${nomeHeroi} | Nasc: ${dataNascimento} | ${altura}cm | ${peso}kg | ${superpoderes}`;


  listaHerois.appendChild(li);


  formulario.reset();
});


function cancelarFormulario() {
  formulario.reset();
}
