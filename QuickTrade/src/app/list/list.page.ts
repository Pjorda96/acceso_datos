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

  constructor(private toastController: ToastController, private elementService: ElementService) {}

  ngOnInit() {
    const elements = this.elementService.getElements();

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
      this.elementService.setElement(element);
      this.toast('Elemento añadido correctamente');
      this.resetForm();
    } else {
      this.toast('Revisa los datos', 'danger');
    }
  }
}


/*
import { Component, OnInit } from '@angular/core';
import { ToastController } from '@ionic/angular';
import { IData, IHogar, IInmobiliaria, IMotor, ITecnologia } from '../interfaces';
import { ElementService } from '../services/element.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit {
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
      this.elementService.setElement(element);
      this.toast('Elemento añadido correctamente');
      this.resetForm();
    } else {
      this.toast('Revisa los datos', 'danger');
    }
  }
}
*/
