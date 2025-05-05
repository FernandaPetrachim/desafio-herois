import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

interface Heroi {
  nomeHeroi: string;
  dataNascimento: string;
  altura: number;
  peso: number;
  superpoderes: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  formularioVisivel = true;
  nomeHeroi = '';
  dataNascimento = '';
  altura = 0;
  peso = 0;
  superpoderes = '';

  herois: Heroi[] = [];
}

