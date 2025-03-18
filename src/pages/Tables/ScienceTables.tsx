import ScienceTabalesHeader from "../../components/common/ScienceTabalesHeader";
import ComponentCard from "../../components/common/ComponentCard";
import ScienceTables from "../../components/tables/ScienceTables/ScienceTables";

export default function BasicTables() {
  return (
    <>
        {/* HEADER TABLE NẾU MUỐN CÓ NÚT THÊM */}
      {/* <ScienceTabalesHeader pageTitle="Công bố khoa học" /> */}
      <div className="space-y-6">
        <ComponentCard title="Công bố khoa học">
          <ScienceTables></ScienceTables>
        </ComponentCard>
      </div>
    </>
  );
}
