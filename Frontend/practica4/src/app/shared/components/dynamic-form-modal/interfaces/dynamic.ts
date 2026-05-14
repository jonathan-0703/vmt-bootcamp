export interface DynamicField {

    key: string;

    label: string;

    type: 'text' | 'email' | 'number';

    required?: boolean;

}