import ComponentCard from "../../components/common/ComponentCard";
import MagazineTablesOne from "../../components/tables/Magazine/MagazineTablesOne";

export default function MagazineTables() {
  // const navigate = useNavigate();

  // const handleAddClick = () => {
  //     const isConfirmed = window.confirm("Bạn có chắc chắn muốn thêm không?");
  //     if (isConfirmed) {
  //         navigate(' ');
  //     } else {
  //         alert("Hành động đã được hủy bỏ.");
  //     }
  // };

  return (
    <>
      {/* <div className="flex flex-wrap items-center justify-between gap-3 mb-6">
                <div></div>
                <div className="action">
                    <button
                        onClick={handleAddClick}
                        className="flex items-center gap-1.5 px-5 py-1.5 bg-[#145efc] hover:bg-[#145efc]/90 text-white rounded-lg transition-all duration-200 dark:bg-[#145efc] dark:hover:bg-[#145efc]/80"
                    >
                        <span className="text-lg font-bold">+</span>
                        Thêm
                    </button>
                </div>
            </div> */}
      <div className="space-y-6">
        <ComponentCard title="Danh sách">
          <MagazineTablesOne />
        </ComponentCard>
      </div>
    </>
  );
}
