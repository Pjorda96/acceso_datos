import { Component, OnInit } from '@angular/core';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {ElementService} from '../services/element.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {
  data: (IData | IMotor | IInmobiliaria | ITecnologia | IHogar)[] = [];

  constructor(private elementService: ElementService) {}

  ngOnInit() {
    const elements = this.elementService.getElements();

    elements.once('value', snapshot => {
      snapshot.forEach(child => {
        const value = child.val();
        this.data.push(value);
      });
    });
  }
}
