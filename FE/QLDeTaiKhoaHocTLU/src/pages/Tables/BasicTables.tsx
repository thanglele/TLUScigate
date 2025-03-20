import PageBreadcrumb from "../../components/common/PageBreadCrumb";
import ComponentCard from "../../components/common/ComponentCard";
import BasicTableOne from "../../components/tables/BasicTables/BasicTableOne";

export default function BasicTables() {
  return (
    <>
      <PageBreadcrumb pageTitle="Giảng Viên" />
      <div className="space-y-6">
        <ComponentCard title="Danh sách">
          <BasicTableOne />
        </ComponentCard>
      </div>
    </>
  );
}
