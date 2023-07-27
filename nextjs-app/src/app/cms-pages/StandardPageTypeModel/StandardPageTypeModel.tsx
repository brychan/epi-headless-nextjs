import styles from "./StandardPageTypeModel.module.css";
import { ContentArea } from "@/app/cms-blocks/ContentArea";
import { StandardPageType } from "./StandardPageTypeModelType";
import HeroElement from "@/components/HeroElement/HeroElement";

const StartPageTypeModel = ({ model }: { model: StandardPageType }) => {
  if (!model) return <div>Error: No model</div>;

  return (
    <div className={styles.page}>
      <HeroElement heading={model.heading?.value} />
      <div className={styles.contentArea}>
        <ContentArea model={model.contentBlocks} name={"ContentBlocks"} />
      </div>
    </div>
  );
};

export default StartPageTypeModel;
