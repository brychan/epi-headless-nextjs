import { ContentAreaType, ContentLinkWithId } from "../../types";

import { ContentData } from "@episerver/content-delivery";

import blocksList from "./blocksList";

export const ContentArea = ({
  model,
  name,
}: {
  model: ContentAreaType;
  name: string;
}) => {
  if (!model) return null;
  const blocks = (model.expandedValue as ContentData[])?.map((block, index) => {
    const Block = blocksList[block.contentType[1]];
    return Block ? (
      <Block key={index} model={block} value={model.value[index]} />
    ) : null;
  });

  return blocks;
};
