import { Suspense } from "react";

import { ContentArea } from "@/app/cms-blocks/ContentArea";
import { StartPageType } from "./StartPageTypeModelType";

import CoinDeskData from "@/components/CoinDeskData/CoinDeskData";
import Loading from "@/components/Loading/loading";
import HeroElement from "@/components/HeroElement/HeroElement";
import styles from "./StartPageTypeModel.module.css";

export default async function StartPageTypeModel({
  model,
}: {
  model: StartPageType;
}) {
  if (!model) return <div>Error: No model</div>;

  return (
    <main>
      <HeroElement heading={model.heroHeading?.value} backgroundImage={model.heroBackgroundImage?.value?.url}/>
      <div>
        <Suspense fallback={<Loading />}>
          <CoinDeskData />
        </Suspense>
      </div>
      <div className={styles.contentArea}>
        <ContentArea model={model.contentBlocks} name="ContentBlocks" />
      </div>
    </main>
  );
}
