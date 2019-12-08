import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  categoria: string | undefined = undefined;

  constructor() {}

  onSelectChange(event): void {
    this.categoria = event.detail.value;
  }

}
