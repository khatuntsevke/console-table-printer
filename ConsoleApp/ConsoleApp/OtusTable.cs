using System;
using System.Text;


public class BoxWithText
{
	private StringBuilder boxFiller;
    private StringBuilder[] linesWithText;
    private int dimension;
    public int width; // ширина 
    public int height; // высота

    public BoxWithText(string tableText, int tableDimension, int maxLineSize)
    {
        dimension = tableDimension;
        
        int chunkSize = maxLineSize - 2 * dimension;
        var textChunks = tableText.Chunk(chunkSize).ToArray();

        width = textChunks[0].Length + 2 * dimension;
        height = 2 * dimension - 2 + textChunks.Length;

        linesWithText = new StringBuilder[textChunks.Length];
        for (int i = 0; i < linesWithText.Length; i++)
        {
            linesWithText[i] = new StringBuilder();
            linesWithText[i].Append('+');
            linesWithText[i].Append(' ', dimension - 1);
            linesWithText[i].Append(textChunks[i]);
            linesWithText[i].Append(' ', width - dimension - textChunks[i].Length - 1);
            linesWithText[i].Append('+');
        }

        boxFiller = new StringBuilder();
        boxFiller.Append('+');
        boxFiller.Append(new String(' ', width - 2));
        boxFiller.Append('+');
    }
	

    public void Print()
    {
        for(int i = 1; i < dimension; i++)
        { 
            Console.WriteLine(boxFiller.ToString());
        }

        for (int i = 0; i < linesWithText.Length; i++)
        {
            Console.WriteLine(linesWithText[i].ToString());
        }

        for (int i = 1; i < dimension; i++)
        {
            Console.WriteLine(boxFiller.ToString());
        }
    }
}

public class ChessBoard
{
    private StringBuilder evenStrBoard;
    private StringBuilder oddStrBoard;
    public int height;
    public ChessBoard(int width, int height)
    {
        this.height = height;
        evenStrBoard = new StringBuilder();
        oddStrBoard = new StringBuilder();
        for (int row = 0; row < width; row++)
        {
            if (row % 2 == 0)
            {
                evenStrBoard.Append(' ');
                oddStrBoard.Append('+');
            }
            else
            {
                evenStrBoard.Append('+');
                oddStrBoard.Append(' ');
            }
        }
    }
    public void Print()
    {
        for(int row=0; row<height; row++)
        {
            string rowStr = (row % 2 == 0) ? evenStrBoard.ToString() : oddStrBoard.ToString();
            Console.WriteLine(rowStr);
        }
    }
}

public class HourGlass
{    
    private int width;
    public HourGlass(int width)
    {
        this.width = width;
    }
    public void Print()
    {
        for (int row = 0; row < width; row++)
        {
            for (int col = 0; col < width; col++)
            {
                char c = (col == row || col == width - 1 - row) ? '+' : ' ';
                Console.Write(c);
            }            
            Console.WriteLine();
        }
    }

}

public class OtusTable
{
	// config
	private readonly int maxRowSize;
	private int dimension;    
	// primitives
	private StringBuilder horizontalBorder;
	private BoxWithText boxWithText;
	private ChessBoard chessBoard;
	private HourGlass hourGlass;

	public OtusTable(string tableText, int tableDimension, int maxRowSize = 40)
	{
		dimension = tableDimension;
        this.maxRowSize = maxRowSize;

        boxWithText = new BoxWithText(tableText, tableDimension, maxRowSize);
        
        horizontalBorder = new StringBuilder();
        horizontalBorder.Append('+', boxWithText.width);

        chessBoard = new ChessBoard(boxWithText.width, boxWithText.height);

        hourGlass = new HourGlass(boxWithText.width);
    }

	public void Print()
	{
        for (uint row = 0; row < 3; row++)
        {
            Console.WriteLine(horizontalBorder.ToString());
            switch (row)
            {
                case uint x when x % 3 == 0:
                    boxWithText.Print();
                    break;
                case uint x when x % 3 == 1:
                    chessBoard.Print();
                    break;
                case uint x when x % 3 == 2:
                    hourGlass.Print();
                    break;
                default:
                    Console.WriteLine("Ошибка! Не предусмотренный тип строчки таблицы.");
                    break;
            }
        }        
        Console.WriteLine(horizontalBorder.ToString());
    }
}

