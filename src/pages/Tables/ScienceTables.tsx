
import ComponentCard from "../../components/common/ComponentCard";
import ScienceTablesOne from "../../components/tables/ScienceTables/ScienceTablesOne";
import PageBreadcrumb from "../../components/common/PageBreadCrumb";

export default function ScienceTables() {
  return (
    <>
      {/* HEADER TABLE NẾU MUỐN CÓ NÚT THÊM */}
      {/* <ScienceTabalesHeader pageTitle="Công bố khoa học" /> */}
      <PageBreadcrumb pageTitle="Giảng Viên" />
      <div className="space-y-6">
        <ComponentCard title="Công bố khoa học">
           <ScienceTablesOne />
        </ComponentCard>
      </div>
    </>
  );
}
