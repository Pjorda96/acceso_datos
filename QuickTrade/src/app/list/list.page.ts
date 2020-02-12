import { Component, OnInit } from '@angular/core';
import { ToastController } from '@ionic/angular';
import { IData, IHogar, IInmobiliaria, IMotor, ITecnologia } from '../interfaces';
import { ElementService } from '../services/element.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {
  data: (IData | IHogar| IInmobiliaria| IMotor| ITecnologia)[] = [];

  constructor(private toastController: ToastController, private elementService: ElementService) {}

  ngOnInit() {
    this.data = this.elementService.getElements();
  }
}
