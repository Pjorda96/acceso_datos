import { Component, OnInit } from '@angular/core';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import { ElementService } from '../services/element.service';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.page.html',
  styleUrls: ['./filters.page.scss'],
})
export class FiltersPage implements OnInit {
  nombre: string;
  data: (IData | IHogar| IInmobiliaria| IMotor| ITecnologia)[] = [];

  constructor(private elementService: ElementService) { }

  ngOnInit() {
  }

  buscar() {
    this.data = this.elementService.searchByName(this.nombre);
  }

}
