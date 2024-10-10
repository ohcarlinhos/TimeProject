namespace Shared.General.Pagination;

public class HistoryPaginationQuery : PaginationQuery
{
    private int _perPage = 9;

    public override int PerPage
    {
        get => _perPage;
        set
        {
            switch (value)
            {
                case < 0:
                    _perPage = 0;
                    return;
                case > 36:
                    _perPage = 36;
                    return;
            }
        }
    }
}