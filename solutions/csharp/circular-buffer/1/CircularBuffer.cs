using System;

public class CircularBuffer<T>
{
    int writeIndex_;
    int readIndex_;
    int size_;
    int capacity_;
    T[] buffer_;

    public CircularBuffer(int capacity)
    {
        this.capacity_ = capacity;
        this.buffer_ = new T[capacity];
        this.writeIndex_ = 0;
        this.readIndex_ = 0;
        this.size_ = 0;

    }

    public T Read()
    {
        if (size_ == 0)
        {
            throw new InvalidOperationException("Nothing to read...");
        }

        T value = buffer_[readIndex_];

        readIndex_ = (readIndex_ + 1) % capacity_;
        size_--;

        return value;
    }

    public void Write(T value)
    {
      
        if(size_ == capacity_)
        {
            throw new InvalidOperationException("capacity is full...");
        }

        buffer_[writeIndex_] = value;
        size_++;
        writeIndex_ = (writeIndex_ + 1) % capacity_;
            
        
    }

    public void Overwrite(T value)
    {
        if(size_ == capacity_)
        {
            buffer_[writeIndex_] = value;

            readIndex_ = (readIndex_ + 1) % capacity_;

            writeIndex_ = (writeIndex_ + 1) % capacity_;

        }
        else
        {
            Write(value);
        }
    }

    public void Clear()
    {
        writeIndex_ = 0;
        readIndex_ = 0;
        size_ = 0;
    }
}