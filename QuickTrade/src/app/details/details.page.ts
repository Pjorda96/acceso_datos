import { Component, OnInit } from '@angular/core';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia, emptyElement} from '../interfaces';
import {ActivatedRoute} from '@angular/router';
import {ElementService} from '../services/element.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.page.html',
  styleUrls: ['./details.page.scss'],
})
export class DetailsPage implements OnInit {
  element: (IData | IMotor | IInmobiliaria | ITecnologia | IHogar) = emptyElement;

  constructor(private activatedRoute: ActivatedRoute, private elementService: ElementService) { }

  ngOnInit() {
    const key: string = this.activatedRoute.snapshot.paramMap.get('id');
    const elem = this.elementService.getElement(key);

    elem.once('value').then(snapshot => {
      let value = snapshot.val();
      value = {
        ...value,
        id: snapshot.key,
      };
      this.element = value;
    });
  }

}
