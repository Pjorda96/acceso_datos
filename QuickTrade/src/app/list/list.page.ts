import { Component, OnInit } from '@angular/core';
import { data } from '../../global/storage';
import {IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {
  data: (IMotor | IInmobiliaria | ITecnologia | IHogar)[];

  constructor() {}

  ngOnInit() {
    this.data = data;
  }

}
