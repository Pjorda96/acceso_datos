export interface IData {
    id?: number;
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
