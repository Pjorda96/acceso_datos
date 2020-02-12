import { Component, OnInit } from '@angular/core';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {ToastController} from '@ionic/angular';
import {ElementService} from '../services/element.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.page.html',
  styleUrls: ['./create.page.scss'],
})
export class CreatePage implements OnInit {
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
  user = 'pjorda96'; // obtener del login

  constructor(private toastController: ToastController, private elementService: ElementService) {}

  ngOnInit() {
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
    let element: IData | IMotor | IInmobiliaria | ITecnologia | IHogar = {
      nombre: this.nombre,
      descripcion: this.descripcion,
      categoria: this.categoria,
      precio: this.precio,
      usuario: this.elementService.getUserkey(this.user),
    };

    if (this.categoria === 'tecnologia') {
      element = {
        ...element,
        estado: this.estado,
      };
    }

    if (this.categoria === 'motor') {
      element = {
        ...element,
        tipoMotor: this.tipoMotor,
        kilometros: this.kilometros,
      };
    }

    if (this.categoria === 'inmobiliaria') {
      element = {
        ...element,
        metros_cuadrados: this.metrosCuadrados,
        banos: this.banos,
        habitaciones: this.habitaciones,
        localidad: this.localidad,
      };
    }

    if (esValido) {
      this.elementService.addElement(element);
      this.toast('Elemento añadido correctamente');
      this.resetForm();
    } else {
      this.toast('Revisa los datos', 'danger');
    }
  }
}
