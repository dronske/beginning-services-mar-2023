import { LocationEntity } from "../state";
import { FormControl } from "@angular/forms";

export type FormDataType<T> = {
    [Property in keyof T]: FormControl<T[Property]>;
  };

  
export type LocationCreate = Pick<LocationEntity, 'name' | 'description' >;