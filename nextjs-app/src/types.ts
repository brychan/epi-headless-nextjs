import { ContentData, ContentLink } from "@episerver/content-delivery";

export interface PageContentType {
  model: ContentData;
  status: string;
  modelLoaded: boolean;
}

export interface ContentAreaType {
  expandedValue: ContentData[];
  value: any;
  propertyDataType: "PropertyContentArea";
}

export interface PropertyContent {
  value: string;
  propertyDataType: string;
}

export interface PropertyContentReference {
  guidValue: string;
  id: number;
  url: string;
}

export interface ContentLinkWithId extends ContentLink {
  id: number;
}

export interface PropertyContentImage {
  value: PropertyContentReference;
}
