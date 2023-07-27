import { ContentData } from "@episerver/content-delivery";
import { PropertyContent } from "../../../types";

export interface TextBlockType extends ContentData {
  heading: PropertyContent;
  textBody: PropertyContent;
}
