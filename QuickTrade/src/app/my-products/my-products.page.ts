import { Component, OnInit } from '@angular/core';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {ElementService} from '../services/element.service';

@Component({
  selector: 'app-my-products',
  templateUrl: './my-products.page.html',
  styleUrls: ['./my-products.page.scss'],
})
export class MyProductsPage implements OnInit {
  data: (IData | IHogar| IInmobiliaria| IMotor| ITecnologia)[] = [];

  constructor(private elementService: ElementService) { }

  ngOnInit() {
    const elements = this.elementService.getMyElements();

    elements.once('value', snapshot => {
      snapshot.forEach(child => {
        let value = child.val();
        value = {
          ...value,
          id: child.key,
        };
        this.data.push(value);
      });
    });
  }

}
