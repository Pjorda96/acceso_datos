import { Component, OnInit } from '@angular/core';
import { data } from '../../global/storage';
import {IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.page.html',
  styleUrls: ['./details.page.scss'],
})
export class DetailsPage implements OnInit {
  element: (IMotor | IInmobiliaria | ITecnologia | IHogar);

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    const res = this.activatedRoute.snapshot.paramMap.get('id');
    this.element = data[res];
  }

}
