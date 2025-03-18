import {
    Table,
    TableBody,
    TableCell,
    TableHeader,
    TableRow,
} from "../../ui/table";
import { FiEye, FiEdit, FiTrash2 } from "react-icons/fi";

interface Magazine {
    id: number;
    name: string;
    category: string;
    author: string;
    country: string;
    year: string;
}

// Define the table data using the interface
const tableData: Magazine[] = [
    {
        id: 1,
        name: "HỆ THỐNG AN TOÀN MẠNG TRONG TRƯỜNG DH",
        category: "Tạp chí",
        author: "Ngô Minh Trung",
        country: "Việt Nam",
        year: "08/01/2005",
    },
    {
        id: 2,
        name: "HỆ THỐNG AN TOÀN MẠNG TRONG TRƯỜNG DH",
        category: "Tạp chí",
        author: "Ngô Minh Trung",
        country: "Việt Nam",
        year: "08/01/2005",
    },
    {
        id: 3,
        name: "HỆ THỐNG AN TOÀN MẠNG TRONG TRƯỜNG DH",
        category: "Báo cáo",
        author: "Ngô Minh Trung",
        country: "Việt Nam",
        year: "08/01/2005",
    },
    {
        id: 4,
        name: "HỆ THỐNG AN TOÀN MẠNG TRONG TRƯỜNG DH",
        category: "Tạp chí",
        author: "Ngô Minh Trung",
        country: "Việt Nam",
        year: "08/01/2005",
    },
    {
        id: 5,
        name: "HỆ THỐNG AN TOÀN MẠNG TRONG TRƯỜNG DH",
        category: "Báo cáo",
        author: "Ngô Minh Trung",
        country: "Việt Nam",
        year: "08/01/2005",
    },
    {
        id: 6,
        name: "HỆ THỐNG AN TOÀN MẠNG TRONG TRƯỜNG DH",
        category: "Tạp chí",
        author: "Ngô Minh Trung",
        country: "Việt Nam",
        year: "08/01/2005",
    }
];

// VIET CHI TIET SAU
const handleViewDetail = (id: number) => {

};

const handleEdit = (id: number) => {
    console.log('Sửa thông tin giảng viên:', id);
};

const handleDelete = (id: number) => {
    console.log('Xóa giảng viên:', id);
};


export default function MagazineTablesOne() {
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
                                    TÊN ẤN PHẨM
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    LOẠI ẤN PHẨM
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    TÁC GIẢ
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    QUỐC GIA
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    NĂM XUẤT BẢN
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
                            {tableData.map((Magazine) => (
                                <TableRow key={Magazine.id}>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Magazine.id}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Magazine.name}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Magazine.category}
                                    </TableCell>
                                    
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Magazine.author}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Magazine.country}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Magazine.year}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        <div className="flex items-center gap-2">
                                            {/* Nút Xem chi tiết */}
                                            <button
                                                className="text-blue-600 hover:text-blue-900 transition-colors"
                                                onClick={() => handleViewDetail(Magazine.id)}
                                            >
                                                <FiEye className="w-4 h-4" />
                                            </button>

                                            {/* Nút Sửa */}
                                            <button
                                                className="text-green-600 hover:text-green-900 transition-colors"
                                                onClick={() => handleEdit(Magazine.id)}
                                            >
                                                <FiEdit className="w-4 h-4" />
                                            </button>

                                            {/* Nút Xóa */}
                                            <button
                                                className="text-red-600 hover:text-red-900 transition-colors"
                                                onClick={() => handleDelete(Magazine.id)}
                                            >
                                                <FiTrash2 className="w-4 h-4" />
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
