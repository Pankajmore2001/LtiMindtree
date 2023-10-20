using Entity;
using DataLayer;
namespace BzLayer;

public class MovieBz
{
public List<Movie> GetMovies(){
    DataAccess dataAccess = new DataAccess();
    return dataAccess.GetMovies();
}
}
