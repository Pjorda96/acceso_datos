import { Component } from '@angular/core';
import { ToastController } from '@ionic/angular';
import { data } from '../../global/storage';
import { IData, IHogar, IInmobiliaria, IMotor, ITecnologia } from '../interfaces';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  nombre: string;
  descripcion: string;
  categoria: string | undefined = undefined;
  tipoMotor: string;
  kilometros: number;
  metrosCuadrados: number;
  banos: number;
  habitaciones: number;
  localidad: string;
  estado: string;
  precio: number;
  data: (IMotor | IInmobiliaria | ITecnologia | IHogar)[];

  constructor(private toastController: ToastController) {
    this.data = data;
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

  resetForm(): void {
    this.nombre = undefined;
    this.descripcion = undefined;
    this.categoria = undefined;
    this.tipoMotor = undefined;
    this.kilometros = undefined;
    this.metrosCuadrados = undefined;
    this.banos = undefined;
    this.habitaciones = undefined;
    this.localidad = undefined;
    this.estado = undefined;
    this.precio = undefined;
  }

  insertar(): void {
    const esValido = this.nombre && this.descripcion && this.categoria && this.precio;
    const elemento: IData = {
      id: data.length + 1,
      nombre: this.nombre,
      descripcion: this.descripcion,
      categoria: this.categoria,
      precio: this.precio,
    };

    if (esValido) {
      data.push(elemento);
      this.toast('Elemento añadido correctamente');
      this.resetForm();
    } else {
      this.toast('Revisa los datos', 'danger');
    }
  }
}
