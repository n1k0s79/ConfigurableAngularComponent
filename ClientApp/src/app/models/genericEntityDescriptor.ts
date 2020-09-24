import { GenericEntityField } from './genericEntityField';

export interface GenericEntityDescriptor {
typeName: string;
title: string;
fields: GenericEntityField[];
entityActions: string[];
listActions: string[];
}
