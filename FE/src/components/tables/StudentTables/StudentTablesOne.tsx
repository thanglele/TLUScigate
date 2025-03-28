import { useNavigate } from "react-router-dom"; 
import 'react-confirm-alert/src/react-confirm-alert.css';
import {
    Table,
    TableBody,
    TableCell,
    TableHeader,
    TableRow,
} from "../../ui/table";
//@ts-ignore
import {fetchNCKHSinhVien} from "../../../api/NCKHSinhVienAPI";

import Badge from "../../ui/badge/Badge";
import { FiEye, FiEdit, FiTrash2, FiClock} from "react-icons/fi";
import { useEffect, useState } from "react";

interface Student {
    id: number;
    tenHoatDong: string;
    tenGiangVien: string;
    kinhPhiHd: string;
    diaDiem: string;
    trangThai: string;
    fileHoanThanh: string;
    ngayBatDau: string;
    ngayKetThuc: string;
}


export default function StudentTablesOne() {
    const navigate = useNavigate(); 

    
    const handleViewDetail = (id: number) => {
        console.log("Log: " + id);
        navigate(`/xem-chi-tiet-sinh-vien`); 
    };

    const handleEdit = (id: number) => {
        console.log('Sửa thông tin giảng viên:', id);
    };

    const handleDelete = (id: number) => {
        const confirmDelete = window.confirm("Bạn có muốn không?");
        if (confirmDelete) {
            console.log("Xóa thành công", id);
        } else {
            console.log("Hủy bỏ ", id);
        }
    };

    const handleClock = (id: number) => {
        console.log("Log: " + id);
        navigate(`/cap-nhat-tien-do-sv`)
    };


    const [studentData, setStudentData] = useState<Student[]>([]);
          const [loading, setLoading] = useState(true);
          const [error, setError] = useState<string | null>(null);
        
          useEffect(() => {
            const loadFacultyData = async () => {
              try {
                const response = await fetchNCKHSinhVien();
                console.log("Fetched Data:", response);
                setStudentData(response);
              } catch (error) {
                const err = error as Error;
                setError(
                  err.message || "Không thể tải dữ liệu từ API. Vui lòng thử lại sau!"
                );
                console.error("Fetch error:", error);
              } finally {
                setLoading(false);
              }
            };
        
            loadFacultyData();
          }, []);
        
          if (loading) return <div className="text-gray-500">Đang tải dữ liệu...</div>;
          if (error) return <div className="text-red-500">{error}</div>;


    return (
        <div className="overflow-hidden rounded-xl border border-gray-200 bg-white dark:border-white/[0.05] dark:bg-white/[0.03]">
            <div className="max-w-full overflow-x-auto">
                <div className="min-w-[1102px]">
                   
                    <Table>
                        <TableHeader className="border-b border-gray-100 dark:border-white/[0.05]">
                            <TableRow>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    ID
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    TÊN ĐỀ TÀI
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    GIẢNG VIÊN HƯỚNG DẪN
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                   KINH PHÍ
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    ĐỊA ĐIỂM
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    TRẠNG THÁI
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                   NGÀY BẮT ĐẦU 
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                   NGÀY KẾT THÚC
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                   FILE HOÀN THÀNH 
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    HÀNH ĐỘNG
                                </TableCell>

                            </TableRow>
                        </TableHeader>

                        {/* Table Body */}
                        <TableBody className="divide-y divide-gray-100 dark:divide-white/[0.05]">
                            {studentData.map((student) => (
                                <TableRow key={student.id}>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {student.id}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {student.tenHoatDong}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {student.tenGiangVien}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {student.kinhPhiHd}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {student.diaDiem}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        <Badge
                                            size="sm"
                                            color={
                                                student.trangThai === "Hoàn thành"
                                                    ? "success"
                                                    : student.trangThai === "Đang thực hiện"
                                                        ? "warning"
                                                        : "error"
                                            }
                                        >
                                            {student.trangThai}
                                        </Badge>
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {student.ngayBatDau}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {student.ngayKetThuc}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {student.fileHoanThanh}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        <div className="flex items-center gap-2">
                                            {/* Nút Xem chi tiết */}
                                            <button
                                                className="text-blue-600 hover:text-blue-900 transition-colors"
                                                onClick={() => handleViewDetail(student.id)}
                                            >
                                                <FiEye className="w-4 h-4" />
                                            </button>

                                            {/* Nút Sửa */}
                                            <button
                                                className="text-green-600 hover:text-green-900 transition-colors"
                                                onClick={() => handleEdit(student.id)}
                                            >
                                                <FiEdit className="w-4 h-4" />
                                            </button>

                                            {/* Nút Xóa */}
                                            <button
                                                className="text-red-600 hover:text-red-900 transition-colors"
                                                onClick={() => handleDelete(student.id)}
                                            >
                                                <FiTrash2 className="w-4 h-4" />
                                            </button>

                                            <button
                                                className="text-purple-600 hover:text-purple-900 transition-colors"
                                                onClick={() => handleClock(student.id)}
                                            >
                                                <FiClock className="w-4 h-4" />
                                            </button>
                                        </div>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </div>
            </div>
        </div>
    );
}
