import { Component, OnInit } from '@angular/core';
import {IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {ActivatedRoute} from '@angular/router';
import {ElementService} from '../services/element.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.page.html',
  styleUrls: ['./details.page.scss'],
})
export class DetailsPage implements OnInit {
  element: (IMotor | IInmobiliaria | ITecnologia | IHogar);

  constructor(private activatedRoute: ActivatedRoute, private elementService: ElementService) { }

  ngOnInit() {
    const res: number = parseInt(this.activatedRoute.snapshot.paramMap.get('id'), 10);
    this.element = this.elementService.getElement(res);
  }

}
