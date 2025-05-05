import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-hero-form',
  standalone: true,
  imports: [FormsModule],
  template: `
  <div>
  <!-- Adicionando a imagem -->
  <img src="assets/marvel.jpg" alt="Imagem do Herói" />

    <form>
      <label>Nome do Herói:</label>
      <input type="text" id="nomeHeroi" [(ngModel)]="nomeHeroi" />

      <label>Data de Nascimento:</label>
      <input type="date" id="dataNascimento" [(ngModel)]="dataNascimento" />

      <label>Altura (cm):</label>
      <input type="number" id="altura" [(ngModel)]="altura" />

      <label>Peso (kg):</label>
      <input type="number" id="peso" [(ngModel)]="peso" />

      <button (click)="salvarHeroi()">Salvar</button>
      <button (click)="cancelar()">Cancelar</button>
    </form>
    </div>
  `,
})
export class HeroFormComponent {
  nomeHeroi: string = '';
  dataNascimento: string = '';
  altura: number | null = null;
  peso: number | null = null;


  salvarHeroi() {
    console.log({
      nomeHeroi: this.nomeHeroi,
      dataNascimento: this.dataNascimento,
      altura: this.altura,
      peso: this.peso,
    });
  }


  cancelar() {
    this.nomeHeroi = '';
    this.dataNascimento = '';
    this.altura = null;
    this.peso = null;
  }
}
