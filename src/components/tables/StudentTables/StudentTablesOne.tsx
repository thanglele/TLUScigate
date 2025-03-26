import { useNavigate } from "react-router-dom"; 
import { confirmAlert } from "react-confirm-alert";
import 'react-confirm-alert/src/react-confirm-alert.css';
import {
    Table,
    TableBody,
    TableCell,
    TableHeader,
    TableRow,
} from "../../ui/table";

import Badge from "../../ui/badge/Badge";
import { FiEye, FiEdit, FiTrash2, FiClock} from "react-icons/fi";

interface Student {
    id: number;
    nameProject: string;
    facultyName: string;
    status: string;
    science: string;
    startDate: string;
    endDate: string;
    teamLeader: string;
}

// Define the table data using the interface
const tableData: Student[] = [
    {
        id: 1,
        nameProject: "Website Quản Lý Phòng Trọ",
        facultyName: "PSG. TS Nguyễn Văn An",
        status: "Đang thực hiện",
        science: "CNTT",
        startDate: "08/01/2005",
        endDate: "08/05/2005",
        teamLeader: "Ngô Minh Trung"

    },
    {
        id: 2,
        nameProject: "Website Quản Lý Phòng Trọ",
        facultyName: "PSG. TS Nguyễn Văn An",
        status: "Đã hoàn thành",
        science: "CNTT",
        startDate: "08/01/2005",
        endDate: "08/05/2005",
        teamLeader: "Ngô Minh Trung"

    },
    {
        id: 3,
        nameProject: "Website Quản Lý Phòng Trọ",
        facultyName: "PSG. TS Nguyễn Văn An",
        status: "Đang thực hiện",
        science: "CNTT",
        startDate: "08/01/2005",
        endDate: "08/05/2005",
        teamLeader: "Ngô Minh Trung"

    },
    {
        id: 4,
        nameProject: "Website Quản Lý Phòng Trọ",
        facultyName: "PSG. TS Nguyễn Văn An",
        status: "Đã hoàn thành",
        science: "CNTT",
        startDate: "08/01/2005",
        endDate: "08/05/2005",
        teamLeader: "Ngô Minh Trung"

    },
    {
        id: 5,
        nameProject: "Website Quản Lý Phòng Trọ",
        facultyName: "PSG. TS Nguyễn Văn An",
        status: "Đang thực hiện",
        science: "CNTT",
        startDate: "08/01/2005",
        endDate: "08/05/2005",
        teamLeader: "Ngô Minh Trung"

    },
    {
        id: 6,
        nameProject: "Website Quản Lý Phòng Trọ",
        facultyName: "PSG. TS Nguyễn Văn An",
        status: "Đã hoàn thành",
        science: "CNTT",
        startDate: "08/01/2005",
        endDate: "08/05/2005",
        teamLeader: "Ngô Minh Trung"

    }
];

export default function StudentTablesOne() {
    const navigate = useNavigate(); 

    
    const handleViewDetail = (id: number) => {
        navigate(`/xem-chi-tiet-sinh-vien`); 
    };

    const handleEdit = (id: number) => {
        console.log('Sửa thông tin giảng viên:', id);
    };

    const handleDelete = (id: number) => {
        const confirmDelete = window.confirm("Bạn có muốn xóa giảng viên này không?");
        if (confirmDelete) {
            console.log("Đã xóa giảng viên với ID:", id);
        } else {
            console.log("Hủy bỏ xóa giảng viên với ID:", id);
        }
    };

    const handleClock = (id: number) => {
        navigate(`/cap-nhat-tien-do-sv`)
    };
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
                                    TRẠNG THÁI
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    KHOA
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
                                    HÀNH ĐỘNG
                                </TableCell>

                            </TableRow>
                        </TableHeader>

                        {/* Table Body */}
                        <TableBody className="divide-y divide-gray-100 dark:divide-white/[0.05]">
                            {tableData.map((Student) => (
                                <TableRow key={Student.id}>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Student.id}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Student.nameProject}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Student.facultyName}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        <Badge
                                            size="sm"
                                            color={
                                                Student.status === "Đã hoàn thành"
                                                    ? "success"
                                                    : Student.status === "Đang thực hiện"
                                                        ? "warning"
                                                        : "error"
                                            }
                                        >
                                            {Student.status}
                                        </Badge>
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Student.science}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Student.startDate}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Student.endDate}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        <div className="flex items-center gap-2">
                                            {/* Nút Xem chi tiết */}
                                            <button
                                                className="text-blue-600 hover:text-blue-900 transition-colors"
                                                onClick={() => handleViewDetail(Student.id)}
                                            >
                                                <FiEye className="w-4 h-4" />
                                            </button>

                                            {/* Nút Sửa */}
                                            <button
                                                className="text-green-600 hover:text-green-900 transition-colors"
                                                onClick={() => handleEdit(Student.id)}
                                            >
                                                <FiEdit className="w-4 h-4" />
                                            </button>

                                            {/* Nút Xóa */}
                                            <button
                                                className="text-red-600 hover:text-red-900 transition-colors"
                                                onClick={() => handleDelete(Student.id)}
                                            >
                                                <FiTrash2 className="w-4 h-4" />
                                            </button>

                                            <button
                                                className="text-purple-600 hover:text-purple-900 transition-colors"
                                                onClick={() => handleClock(Student.id)}
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
