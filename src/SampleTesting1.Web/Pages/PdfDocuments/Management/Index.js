$(function () {
    var l = abp.localization.getResource('SampleTesting1');
    var createModal = new abp.ModalManager(abp.appPath + 'PdfDocuments/Management/AddModal');
    var editModal = new abp.ModalManager(abp.appPath + 'PdfDocuments/Management/EditModal');
    
    var dataTable = $('#PdfDocumentsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "desc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(sampleTesting1.pdfDocuments.pdfDocument.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items: [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('SampleTesting1.PdfDocuments.Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('SampleTesting1.PdfDocuments.Delete'),
                                confirmMessage: function (data) {
                                    return l('PdfDocumentDeletionConfirmationMessage', data.record.title);
                                },
                                action: function (data) {
                                    sampleTesting1.pdfDocuments.pdfDocument
                                        .delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                    }
                },
                {
                    title: l('Title'),
                    data: "title"
                },
                {
                    title: l('Category'),
                    data: "category"
                },
                {
                    title: l('CreationTime'),
                    data: "creationTime",
                    dataFormat: "datetime"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewPdfDocumentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
