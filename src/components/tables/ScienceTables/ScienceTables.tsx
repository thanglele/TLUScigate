import {
    Table,
    TableBody,
    TableCell,
    TableHeader,
    TableRow,
} from "../../ui/table";

import { FiEye, FiEdit, FiTrash2 } from "react-icons/fi";

interface Science {
    id: number;
    title: string;
    language: string;
    author: string;
    indexScience: string;
    publicDate: string;
}

// Define the table data using the interface
const tableData:Science[] = [
    {
        id: 1,
        title: "Ngô Minh Trung",
        language: "ngominhtrung@tlu.edu.vn",
        author: "Đang làm việc",
        indexScience: "SSCI",
        publicDate: "Khoa học Máy tính",

    },
    {
        id: 2,
        title: "Ngô Minh Trung",
        language: "ngominhtrung@tlu.edu.vn",
        author: "Đang làm việc",
        indexScience: "SSCI",
        publicDate: "Khoa học Máy tính",

    },
    {
        id: 3,
        title: "Ngô Minh Trung",
        language: "ngominhtrung@tlu.edu.vn",
        author: "Đang làm việc",
        indexScience: "SSCI",
        publicDate: "Khoa học Máy tính",

    },
    {
        id: 4,
        title: "Ngô Minh Trung",
        language: "ngominhtrung@tlu.edu.vn",
        author: "Đang làm việc",
        indexScience: "SSCI",
        publicDate: "Khoa học Máy tính",

    },
    {
        id: 5,
        title: "Ngô Minh Trung",
        language: "ngominhtrung@tlu.edu.vn",
        author: "Đang làm việc",
        indexScience: "SSCI",
        publicDate: "Khoa học Máy tính",

    },
    {
        id: 6,
        title: "Ngô Minh Trung",
        language: "ngominhtrung@tlu.edu.vn",
        author: "Đang làm việc",
        indexScience: "SSCI",
        publicDate: "Khoa học Máy tính",

    },
    
];

// VIET CHI TIET SAU
const handleViewDetail = (id: number) => {

};

export default function ScienceTables() {
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
                                    NGÔN NGỮ
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
                                    CHỈ MỤC KHOA HỌC
                                </TableCell>
                                <TableCell
                                    isHeader
                                    className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                                >
                                    NĂM COONNG BỐ
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
                            {tableData.map((Science) => (
                                <TableRow key={Science.id}>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Science.id}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Science.title}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Science.language}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Science.author}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Science.indexScience}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Science.publicDate}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        <div className="flex items-center gap-2">
                                            {/* Nút Xem chi tiết */}
                                            <button
                                                className="bg-red-900 text-white"
                                                onClick={() => handleViewDetail(Science.id)}
                                            >
                                                Chi tiết
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
