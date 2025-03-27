import ComponentCard from "../../components/common/ComponentCard";
import StudentTablesOne from "../../components/tables/StudentTables/StudentTablesOne";

import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function StudentTable() {
  const navigate = useNavigate();

  const [selectedOption, setSelectedOption] = useState("oke");

  const handleAddClick = () => {
    const isConfirmed = window.confirm("Bạn có chắc chắn muốn thêm không?");
    if (isConfirmed) {
      navigate('/sinh-vien-nckh');
    } else {
      alert("Hành động đã được hủy bỏ.");
    }
  };

  const handleSelectChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setSelectedOption(e.target.value);
  };

  return (
    <>
      <div className="flex flex-wrap items-center justify-between gap-3 mb-6">
        <div className="flex items-center gap-4">
          <label htmlFor="status" className="">Đề tài nghiên cứu sinh viên:</label>
          <select
            id="status"
            value={selectedOption}
            onChange={handleSelectChange}
            className="border outline-none"
          >
            <option value="oke">Đã duyệt</option>
            <option value="pending">Chờ xử lý</option>
            <option value="done">Đã hoàn thành</option>
          </select>
        </div>
        <div className="action">
          <button
            onClick={handleAddClick}
            className="flex items-center gap-1.5 px-5 py-1.5 bg-[#145efc] hover:bg-[#145efc]/90 text-white rounded-lg transition-all duration-200 dark:bg-[#145efc] dark:hover:bg-[#145efc]/80"
          >
            <span className="text-lg font-bold">+</span>
            Thêm
          </button>
        </div>
      </div>

      <div className="space-y-6">
        <ComponentCard title="">
          <StudentTablesOne />
        </ComponentCard>
      </div>
    </>
  );
}
