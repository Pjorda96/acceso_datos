export interface IData {
    id?: string;
    user: string;
    nombre: string;
    descripcion: string;
    categoria: string | undefined;
    precio: number;
}

export interface IMotor extends IData {
    tipoMotor: string;
    kilometros: number;
}

export interface IInmobiliaria extends IData {
    metros_cuadrados: number;
    banos: number;
    habitaciones: number;
    localidad: string;
}

export interface ITecnologia extends IData {
    estado: string;
}

export interface IHogar extends IData {
    empty: boolean;
}

export const emptyElement: IData = {
    id: '',
    nombre: '',
    descripcion: '',
    categoria: '',
    precio: 0,
    user: '',
};
