import { Component, OnInit } from '@angular/core';
import {IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {ElementService} from '../services/element.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {
  data: (IMotor | IInmobiliaria | ITecnologia | IHogar)[];

  constructor(private elementService: ElementService) {}

  ngOnInit() {
    this.data = this.elementService.getElements();
  }

}
