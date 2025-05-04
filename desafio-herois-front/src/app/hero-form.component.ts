import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-hero-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <button (click)="abrirFormulario()">Adicionar Herói</button>

    <div *ngIf="formularioAberto()" class="formulario">
      <h2>Novo Herói</h2>
      <label>Nome:</label>
      <input type="text" [(ngModel)]="nome"/>

      <label>Nome de Herói:</label>
      <input type="text" [(ngModel)]="nomeHeroi"/>

      <button (click)="salvarHeroi()">Salvar</button>
      <button (click)="fecharFormulario()">Cancelar</button>
    </div>
  `,
  styles: [`
    .formulario {
      border: 1px solid #ccc;
      padding: 1rem;
      margin-top: 1rem;
    }
  `]
})
export class HeroFormComponent {
  formularioAberto = signal(false);
  nome = '';
  nomeHeroi = '';

  abrirFormulario() {
    this.formularioAberto.set(true);
  }

  fecharFormulario() {
    this.formularioAberto.set(false);
  }

  salvarHeroi() {
    alert(`Herói salvo: ${this.nomeHeroi}`);
    this.fecharFormulario();
  }
}
