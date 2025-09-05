using InExTrack.Common;
using InExTrack.DTOs;
using InExTrack.Interfaces.Repositories;
using InExTrack.Interfaces.Services;
using InExTrack.Models;
using Mapster;

namespace InExTrack.Services
{
    public class TransactionService(ITransactionRepository _transactionRepository) : ITransactionService
    {

        public async Task<ApiResponse<IEnumerable<TransactionDto>>> GetTransactionsAsync(CancellationToken cancellationToken = default)
        {
            var transactions = await _transactionRepository.GetTransactionsAsync(cancellationToken);

            var transactionDtos = transactions.Adapt<IEnumerable<TransactionDto>>();

            return new ApiResponse<IEnumerable<TransactionDto>>(transactionDtos, "Транзакции успешно получены!");
        }

        public async Task<ApiResponse<TransactionDto>> GetTransactionByIdAsync(Guid transactionId, CancellationToken cancellationToken = default)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(transactionId, cancellationToken);

            var transactionDtos = transaction.Adapt<TransactionDto>();

            return new ApiResponse<TransactionDto>(transactionDtos, "Транзакция успешно получено!");
        }

        public async Task<ApiResponse<TransactionDto>> AddTransactionAsync(TransactionDto transactionDto, CancellationToken cancellationToken = default)
        {
            var transactionAdapt = transactionDto.Adapt<Transaction_>();
            var transaction = await _transactionRepository.AddTransactionAsync(transactionAdapt, cancellationToken);

            var transactionDtos = transaction.Adapt<TransactionDto>();
            return new ApiResponse<TransactionDto>(transactionDtos, "Транзакция успешно добавлено!");
        }

        public async Task<ApiResponse<TransactionDto>> UpdateTransactionAsync(Guid id, TransactionDto transactionDto, CancellationToken cancellationToken = default)
        {
            var updatedTransaction = await _transactionRepository.UpdateTransactionAsync(id, transactionDto, cancellationToken);

            var transactionDtos = updatedTransaction.Adapt<TransactionDto>();
            return new ApiResponse<TransactionDto>(transactionDtos, "Транзакция успешно изменено!");
        }

        public async Task<ApiResponse<bool>> DeleteTransactionAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var transactionDtos = await _transactionRepository.DeleteTransactionAsync(id, cancellationToken);

            if (!transactionDtos)
                return new ApiResponse<bool>("Транзакция не найдено!");

            return new ApiResponse<bool>(transactionDtos, "Транзакция успешно удалено!");
        }
    }
}
