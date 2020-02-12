import { Component, OnInit } from '@angular/core';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia, emptyElement} from '../interfaces';
import {ActivatedRoute} from '@angular/router';
import {ElementService} from '../services/element.service';
import {ToastController} from '@ionic/angular';

@Component({
  selector: 'app-details',
  templateUrl: './details.page.html',
  styleUrls: ['./details.page.scss'],
})
export class DetailsPage implements OnInit {
  element: (IData | IMotor | IInmobiliaria | ITecnologia | IHogar) = emptyElement;
  user = 'usuario2';

  constructor(
      private activatedRoute: ActivatedRoute,
      private elementService: ElementService,
      private toastController: ToastController,
  ) { }

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

  async toast(message: string, color?: string): Promise<void> {
    const toast = await this.toastController.create({
      message,
      duration: 2000,
      color,
      showCloseButton: true,
    });
    await toast.present();
  }

  delete() {
    const key: string = this.activatedRoute.snapshot.paramMap.get('id');

    try {
      this.elementService.deleteElement(key);

      this.toast('Elemento eliminado correctamente');
    } catch (e) {
      this.toast(e, 'danger');
    }
  }

}
