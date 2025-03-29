
import ComponentCard from "../../components/common/ComponentCard";
import FacultyTablesOne from "../../components/tables/Faculty/FacultyTablesOne";

import { useNavigate } from "react-router-dom";
//import { useState } from "react";

export default function FacultyTables() {
    const navigate = useNavigate();
    //const [selectedOption, setSelectedOption] = useState("oke");

    const handleAddClick = () => {
        const isConfirmed = window.confirm("Bạn có chắc chắn muốn thêm không?");
        if (isConfirmed) {
            navigate('/giang-vien-nckh');
        } else {
            alert("Hành động đã được hủy bỏ.");
        }
    };
    // const handleSelectChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    //     setSelectedOption(e.target.value);
    //   };

    return (
        <>
            <div className="flex flex-wrap items-center justify-between gap-3 mb-6">
                <div className="flex items-center gap-4">
                    {/* <label htmlFor="status" className="">Đề tài nghiên cứu giảng viên:</label>
                    <select
                        id="status"
                        value={selectedOption}
                        onChange={handleSelectChange}
                        className="border outline-none"
                    >
                        <option value="oke">Đã duyệt</option>
                        <option value="pending">Chờ xử lý</option>
                        <option value="done">Đã hoàn thành</option>
                    </select> */}
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
                <ComponentCard title="Danh sách">
                    <FacultyTablesOne />
                </ComponentCard>
            </div>
        </>
    );
}