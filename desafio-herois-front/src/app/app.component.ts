import { Component } from '@angular/core';
import { HeroFormComponent } from './hero-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HeroFormComponent],
  template: `
    <h1>CRUD de Heróis</h1>
    <app-hero-form></app-hero-form>
  `
})
export class AppComponent {}
