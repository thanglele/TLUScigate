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
    nameProject: string;
    facultyName: string;
    status: string;
    science: string;
    startDate: string;
    endDate: string;
    teamLeader: string;
}

// Define the table data using the interface
const tableData: Science[] = [
    {
        id: 1,
        nameProject: "Nâng cao công tác điều hành doanh nghiệp thông qua phân tích dữ liệu và báo cáo quản trị trên thiết bị di động",
        facultyName: "PSG. TS Nguyễn Văn An",
        status: "Đang thực hiện",
        science: "CNTT",
        startDate: "08/01/2005",
        endDate: "08/05/2005",
        teamLeader: "Ngô Minh Trung"

    }
];

// VIET CHI TIET SAU
const handleViewDetail = (id: number) => {

};

export default function ScienceTablesOne() {
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
                            {tableData.map((Science) => (
                                <TableRow key={Science.id}>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Science.id}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Science.nameProject}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                                        {Science.facultyName}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        <Badge
                                            size="sm"
                                            color={
                                                Science.status === "Đang thực hiện"
                                                    ? "success"
                                                    : Science.status === "Đã hoàn thành"
                                                        ? "warning"
                                                        : "error"
                                            }
                                        >
                                            {Science.status}
                                        </Badge>
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Science.science}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Science.startDate}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        {Science.endDate}
                                    </TableCell>
                                    <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                                        <div className="flex items-center gap-2">
                                            {/* Nút Xem chi tiết */}
                                            <button
                                                className=""
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
