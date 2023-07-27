import { ContentData } from "@episerver/content-delivery";
import {
  PropertyContentReference,
  PropertyContent,
  PropertyContentImage,
} from "../../../types";

export interface TextAndImageBlockType extends ContentData {
  heading: PropertyContent;
  textBody: PropertyContent;
  blockImage: PropertyContentImage;
}
